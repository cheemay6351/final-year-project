import re

# attempt at extracting data from beers

# from pymongo import MongoClient
# from connect import database

# try:
#     client = MongoClient(database['url'])

#     db = client.get_database('Beers_2019')
#     collection = db.get_collection('Table2')

#     collection is empty
#     if collection.count_documents({}) == 0:
#         collection.insert_one({"example_key": "example_value"})

#     document_count = collection.count_documents({})

#     print('Connected successfully to MongoDB.')

# except Exception as e:
#     print('Failed to connect to MongoDB:', str(e))


file_path = 'J American Geriatrics Society - 2019 - .txt'

# with open(file_path, 'r') as file:
# for _ in range(2396):
#     text = file.readline()

# Function to extract the word 6 spaces away from the leftmost side
def extract_word(line):
    # Split the line by spaces
    words = line.split()

    if len(words) > 6:
        return words[6]  # Word 6 spaces away from the leftmost side
    else:
        return None

firstLineNum = 2397
lineNum = 2401

firstHeading = None
secondHeading = None
thirdHeading = None
fourthHeading = None
fifthHeading = None

with open(file_path, "r", encoding="utf-8") as file:
    for line_number, line in enumerate(file, start=1):
        if line_number == lineNum:
            match = re.search(r'(.*?)\)', line)
            if match:
                firstHeading = match.group().strip()

    file.seek(0)

    for line_number, line in enumerate(file, start=1):
        if line_number == firstLineNum:
            words = line.split()
            partFourthHeading = ' '.join(words[:2])
            partFifthHeading = ' '.join(words[2:4])

    file.seek(0)
    
    for line_number, line in enumerate(file, start=1):
        if line_number == lineNum:
            match = re.search(r'\)(\s+\w+){4}', line)
            if match:
                words = match.group().split()[1:]
                if len(words) == 4:
                    secondHeading, thirdHeading, fourthHeading, fifthHeading = words

with open(file_path, "r", encoding="utf-8") as file:
    for line_number, line in enumerate(file, start=1):
        if line_number == 2409:
            lines = file.readlines()

            # Check if the specified line number is within the range of lines
            if line_number >= 0 and line_number < len(lines):
                # Extract the desired line
                line_to_read = lines[line_number]

                # Extract the word 6 spaces away from the leftmost side
                extracted_word = extract_word(line_to_read)

print(extracted_word)
    

fourthHeading = partFourthHeading + ' ' + fourthHeading
fifthHeading = partFifthHeading + ' ' + fifthHeading

print("First Heading:", firstHeading)
print("Second Heading:", secondHeading)
print("Third Heading:", thirdHeading)
print("Fourth Heading:", fourthHeading)
print("Fifth Heading:", fifthHeading)
