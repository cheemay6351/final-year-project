# attempt to clean spaces in the beers critera's pdf file

def remove_spaces(file_path):
    # read the file
    with open(file_path, 'r', encoding="utf-8") as file:
        content = file.read()

    # remove extra spaces
    cleaned_content = ' '.join(content.split())

    # write the cleaned content back to the file
    with open(file_path, 'w', encoding="utf-8") as file:
        file.write(cleaned_content)

# use the function
text_file_path = 'J American Geriatrics Society - 2019 - .txt'
remove_spaces(text_file_path)

# if you want to save the cleaned content to a new file:
cleaned_file_path = "test1.txt"
with open(text_file_path, "r", encoding="utf-8") as file:
    cleaned_content = file.read()

with open(cleaned_file_path, "w", encoding="utf-8") as file:
    file.write(cleaned_content)

