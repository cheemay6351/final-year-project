import re

organ_list = []
cat_list = []
drug_list = []
rat_list = []
rec_list = []
evi_list = []
str_list = []

lines1 = []
current_line1 = ""
TC_to_OS = {}
OS_to_TC = {}
with open("table2Text.txt", "r", encoding="utf-8") as file:
    #get OS
    for line in file: # getting organ list for organ dictionary
        if line.startswith(" " * 6) and line[6:7] != " ": # if line starts with 6 spaces in and the space indent 6 or 7 is not a space
            # split the line into words
            words = line.strip().split()
            # concatenate words with more than one character and add to the organ list
            organ_list.append(' '.join(word for word in words if len(word) > 1))

        elif line.startswith(" " * 7) and line[7:8] != " ": # if line starts with 7 spaces in and the space indent 7 or 8 is not a space
            # split the line into words
            words = line.strip().split()
            # concatenate words with more than one character and add to the organ list
            organ_list.append(' '.join(word for word in words if len(word) > 1))

        # get TC
        # if line starts with 9 or 10 spaces in and NOT 11 spaces in
        if (line.startswith(" " * 9) or line.startswith(" " * 10)) and not line.startswith(" " * 11): 
            # in the case that the line is 9 spaces in and exactly 9 spaces, the character is lowercase or starts with '('
            if line.startswith(" " * 9) and current_line1 and (line[9:10].islower() or line[9:10] == '('):
                # concatenate lines starting with lowercase to the previous line
                current_line1 += " " + line[9:62].strip()
            elif line.startswith(" " * 10) and current_line1 and (line[10:11].islower() or line[10:11] == '('):
                current_line1 += " " + line[10:62].strip()
            else:
                # store the current line
                if current_line1:
                    lines1.append(current_line1)
                current_line1 = line[9:61].strip()

    # add the last line if it exists (this usually does include the last line)
    if current_line1:
        lines1.append(current_line1)

    # process the lines and create the therapeutic category
    for line in lines1:
        words = line.split()
        #print(words)
        cat_list.append(' '.join(word for word in words if len(word) > 1))
    print(cat_list)
    print(organ_list)
######################################################################################################################################################

lines2 = []
current_line2 = ""

with open("table2Text.txt", "r", encoding="utf-8") as file:
    for line in file:
        # Check if the line meets the criteria for indentation and length
        if (line.startswith(" " * 11) or line.startswith(" " * 12)) and not line.startswith(" " * 13):
            #Concatenate lines starting with lowercase to the previous line
            if line.startswith(" " * 11) and current_line2 and (line[11:12].islower() or line[11:12] == '('):
                current_line2 += " " + line[11:62].strip()
            elif line.startswith(" " * 12) and current_line2 and (line[12:13].islower() or line[12:13] == '('):
                current_line2 += " " + line[12:62].strip()
            else:
                # Store the current line
                if current_line2:
                    lines2.append(current_line2)
                current_line2 = line[11:61].strip()

    # Add the last line if it exists
    if current_line2:
        lines2.append(current_line2)

    # Process the lines and create the organ_list
    for line in lines2:
        words = line.split()
        drug_list.append(' '.join(word for word in words if len(word) > 1))

    # Create the organ_dict
    drug_dict = {str(i): value for i, value in enumerate(drug_list)}
    #print(drug_list, len(drug_list))

######################################################################################################################################################

lines3 = []  # Store lines with the specified conditions
current_line3 = ""

with open("table2Text.txt", "r", encoding="utf-8") as file:
    for line in file: # getting rationale list for category dictionary
        indentated_line = line[61:126]
        # Check if the line starts with a space
        if not indentated_line.strip():
            continue  # Ignore lines that start with only spaces

        # Find the first non-space character in the line
        first_char = next((char for char in indentated_line if not char.isspace()), None)

        # Check if the first non-space character is lowercase
        if first_char and first_char.islower() or first_char in ('(', '<', '-'):
            # Concatenate with a space to the previous line
            current_line3 += " " + indentated_line.strip()
        else:
            # If the line starts with an uppercase letter or is empty, store the previous line
            if current_line3:
                lines3.append(current_line3.strip())
            # Reset the current line
            current_line3 = indentated_line.strip()

    # Add the last line to the list
    if current_line3:
        lines3.append(current_line3.strip())          

    # Process the lines and create the organ_list
    for line in lines3:
        words = line.split()
        rat_list.append(' '.join(word for word in words if len(word) > 1))

    rationale_replace1 = rat_list[0] + "\n" + rat_list[1]
    rat_list[0] = rationale_replace1
    del rat_list[1]
    rationale_replace2 = rat_list[10] + "\n" + rat_list[11] + "\n" + rat_list[12]
    rat_list[10] = rationale_replace2
    del rat_list[11:13]
    rationale_replace3 = rat_list[14] + "\n" + rat_list[15]
    rat_list[14] = rationale_replace3
    del rat_list[15]
    rationale_replace4 = rat_list[16] + "\n" + rat_list[17]
    rat_list[16] = rationale_replace4
    del rat_list[17]
    rationale_replace5 = rat_list[22] + "\n" + rat_list[23]
    rat_list[22] = rationale_replace5
    del rat_list[23]
    rationale_replace6 = rat_list[24] + "\n" + rat_list[25]
    rat_list[24] = rationale_replace5
    del rat_list[25]
    rationale_replace7 = rat_list[27] + "\n" + rat_list[28]
    rat_list[27] = rationale_replace7
    del rat_list[28]
    rationale_replace8 = rat_list[32] + " \n" + rat_list[33] + "\n" + rat_list[34]
    rat_list[32] = rationale_replace8
    del rat_list[33:35]
    rationale_replace9 = rat_list[33] + "\n" + rat_list[34]
    rat_list[33] = rationale_replace9
    del rat_list[34]
    # Create the organ_dict
    #rat_dict = {str(i): value for i, value in enumerate(rat_list)}
    #print(rat_list, len(rat_list))

######################################################################################################################################################

lines4 = []  # Store lines with the specified conditions
current_line4 = ""
with open("table2Text.txt", "r", encoding="utf-8") as file:
    for line in file: # getting recommenation list for category dictionary
        indentated_line = line[125:181]

        # Check if the line starts with a space
        if not indentated_line.strip():
            continue  # Ignore lines that start with only spaces

        # Find the first non-space character in the line
        first_char = next((char for char in indentated_line if not char.isspace()), None)

        # Check if the first non-space character is lowercase
        if first_char and first_char.islower():
            # Concatenate with a space to the previous line
            current_line4 += " " + indentated_line.strip()
        else:
            # If the line starts with an uppercase letter or is empty, store the previous line
            if current_line4:
                lines4.append(current_line4.strip())
            # Reset the current line
            current_line4 = indentated_line.strip()

    # Add the last line to the list
    if current_line4:
        lines4.append(current_line4.strip())          

    # Process the lines and create the organ_list
    for line in lines4:
        words = line.split()
        highlights_words = ['Moderate', 'High', 'Low', 'Atri', 'He']
        #print(words)
        words1 = [word for word in words if len(word) > 1 and word not in highlights_words]
        rec_list.append(' '.join(words1))

    recommendation_replace1 = rec_list[10] + "\n" + rec_list[11] + "\n" + rec_list[12]
    rec_list[10] = recommendation_replace1
    del rec_list[11:13]
    # recommendation_replace2 = rec_list[22] + "\n" + rec_list[23]
    # rec_list[22] = recommendation_replace2
    # del rec_list[23]

    # Create the organ_dict
    #rec_dict = {str(i): value for i, value in enumerate(rec_list)}
    #print(rec_list, len(rec_list))

######################################################################################################################################################

lines5 = []  # Store lines with the specified conditions
current_line5 = ""
keep_words = ['low', 'strong', 'moderate', 'high', 'or', 'cream', 'tablets:', 'weak', '>0.125 mg/day:']
remove_words = ['ts:', 'due to', '12 weeks', '(eg oral', 'ID use)', 'ndition or', 'ure of drug']
previous_first_word = None
previous_line = ""
with open("table2Text.txt", "r", encoding="utf-8") as file:
    for line in file:  # getting recommenation list for category dictionary
        indentated_line = line[170:]
        indentated_line = re.sub(r'\b\w\b|,|–|\s+$|®', '', indentated_line)

        if not indentated_line.strip() or len(indentated_line.strip()) == 1:
            continue  # Ignore lines that start with only spaces or contain only one character

        # Check if the line contains only lowercase characters, excluding keep_words
        if all(char.islower() or any(keyword in char for keyword in keep_words) for char in indentated_line.strip()):
            continue

        # Check if any complete word from remove_words is present in the line
        if any(f' {keyword} ' in f' {indentated_line} ' for keyword in remove_words):
            continue

        # Remove part before the first uppercase letter
        match = re.search('[A-Z]', indentated_line)
        if match:
            indentated_line = indentated_line[match.start():]

        # Split the line into two words based on the specified criteria
        words = re.split(r'\s{3,}', indentated_line.strip(), maxsplit=1)
        if len(words) == 2:
            first_list = list(words[:1])
            second_list = list(words[1:])

        evi_list.append(first_list[0])
        str_list.append(second_list[0])
    #print(quality)
    evi_result_list = []
    str_result_list = []
    current_phrase = ""
    current_phrase1 = ""

    for word in evi_list:
        if current_phrase and (word.islower() or word.startswith('>')):
            current_phrase += ' ' + word
        else:
            if current_phrase:
                evi_result_list.append(current_phrase.strip())
                current_phrase = ""
            current_phrase = word

    if current_phrase:
        evi_result_list.append(current_phrase.strip())

    evi_result_list[25] += " moderate"
    evidence_replace1 = evi_result_list[10] + "\n" + evi_result_list[11] + "\n" + evi_result_list[12]
    evi_result_list[10] = evidence_replace1
    del evi_result_list[11:13]
    evidence_replace2 = evi_result_list[22] + "\n" + evi_result_list[23]
    evi_result_list[22] = evidence_replace2
    del evi_result_list[23]

    #print(evi_result_list, len(evi_result_list))

    for word in str_list:
        if current_phrase1 and (word.islower() or word.startswith('>')):
            current_phrase1 += ' ' + word
        else:
            if current_phrase1:
                str_result_list.append(current_phrase1.strip())
                current_phrase1 = ""
            current_phrase1 = word

    if current_phrase1:
        str_result_list.append(current_phrase1.strip())

    strength_replace1 = str_result_list[10] + "\n" + str_result_list[11] + "\n" + str_result_list[12]
    str_result_list[10] = strength_replace1
    del str_result_list[11:13]
    strength_replace2 = str_result_list[22] + "\n" + str_result_list[23]
    str_result_list[22] = strength_replace2
    del str_result_list[23]

    #print(str_result_list, len(str_result_list))