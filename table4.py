import re
import pymongo

from pymongo import MongoClient
from connect import database

drugs = []
rationale = []	
recommendation = []
qualityOfEvidence = []
strengthOfRecommendation = []

current_line = ""
current_line1 = ""
current_line2 = ""
current_line3 = ""
current_line4 = "" 

lines = []
with open("table4Text.txt", "r", encoding="utf-8") as file:
    for line in file: # getting the drugs list
        if line.strip().startswith(""):
            if current_line and line[0:1].islower():
                current_line += " " + line[0:50].strip()
            else:
                # store the current line
                if current_line:
                    lines.append(current_line)
                current_line = line[0:50].strip()
    
    # add the last line if it exists
    if current_line:
        lines.append(current_line)

    # process the lines and create the drug list
    for line in lines:
        words = line.split()
        drugs.append(' '.join(word for word in words if len(word) > 1))

    drug_rep = drugs[1] + "\n" + drugs[2]
    drugs[1] = drug_rep
    del drugs[2]
    drug_rep2 = "\n".join(drugs[3:12])
    drugs[3] = drug_rep2
    del drugs[4:12]

    #print(drugs, len(drugs))

    file.seek(0)

    lines1 = []
    for line in file: # getting the rationale list
        if line.strip().startswith(""):
            if current_line1 and line[59:60].islower():
                current_line1 += " " + line[59:140].strip()
            else:
                # store the current line
                if current_line1:
                    lines1.append(current_line1)
                current_line1 = line[59:140].strip()
    
    # add the last line if it exists
    if current_line1:
        lines1.append(current_line1)

    # process the lines and create the rationale list
    for line in lines1:
        words = line.split()
        rationale.append(' '.join(word for word in words if len(word) > 1))

    #print(rationale, len(rationale))

    file.seek(0)

    lines2 = []
    for line in file: # getting the recommendation list
        indentated_line = line[144:186]
        # check if the line starts with a space
        if not indentated_line.strip():
            continue  # ignore lines that start with only spaces

        # find the first non-space character in the line and can't find it then set to None
        # first_char is set to be the first non-space character
        first_char = next((char for char in indentated_line if not char.isspace()), None)
        if first_char and first_char.islower() or first_char in ('≥', 'V'):
            current_line2 += " " + indentated_line.strip()
        else:
            # store the current line
            if current_line2:
                lines2.append(current_line2)
            current_line2 = indentated_line.strip()
    
    # add the last line if it exists
    if current_line2:
        lines2.append(current_line2)

    # process the lines and create the drug list
    for line in lines2:
        words = line.split()
        recommendation.append(' '.join(word for word in words if len(word) > 1))

    #print(recommendation, len(recommendation))

    file.seek(0)

    lines3 = []
    for line in file: # getting the rationale list
        if line.strip().startswith(""):
            if current_line3 and line[186:210].islower():
                current_line3 += " " + line[186:210].strip()
            else:
                # store the current line
                if current_line3:
                    lines3.append(current_line3)
                current_line3 = line[186:210].strip()
    
    # add the last line if it exists
    if current_line3:
        lines3.append(current_line3)

    # process the lines and create the drug list
    for line in lines3:
        words = line.split()
        qualityOfEvidence.append(' '.join(word for word in words if len(word) > 1))

    #print(qualityOfEvidence, len(qualityOfEvidence))

    file.seek(0)

    lines4 = []
    for line in file: # getting the rationale list
        if line.strip().startswith(""):
            if current_line4 and line[210:222].islower():
                current_line4 += " " + line[210:222].strip()
            else:
                # store the current line
                if current_line4:
                    lines4.append(current_line4)
                current_line4 = line[210:222].strip()
    
    # add the last line if it exists
    if current_line4:
        lines4.append(current_line3)

    # process the lines and create the drug list
    for line in lines4:
        words = line.split()
        strengthOfRecommendation.append(' '.join(word for word in words if len(word) > 1))

    #print(strengthOfRecommendation, len(strengthOfRecommendation))

    array = list(zip(drugs, rationale, recommendation, qualityOfEvidence, strengthOfRecommendation))

    #print(array[1])

    client = pymongo.MongoClient(database["url"])
    database = client["Beers2019"]
    collection = database["Table4"]
    
    try:
        # Iterate through each entry in combined_2d_array and insert it into MongoDB
        for entry in array:
            document = {
                "Drug(s)": entry[0],
                "Rationale": entry[1],
                "Recommendation": entry[2],
                "Quality of Evidence": entry[3],
                "Strength of Recommendation": entry[4]
            }
            collection.insert_one(document)

        print('Connected successfully to MongoDB.')
    except Exception as e:
        print('Failed to connect to MongoDB:', str(e))
