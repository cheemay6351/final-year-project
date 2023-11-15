def remove_spaces(file_path):
    # Read the file
    with open(file_path, 'r', encoding="utf-8") as file:
        content = file.read()

    # Remove extra spaces
    cleaned_content = ' '.join(content.split())

    # Write the cleaned content back to the file
    with open(file_path, 'w', encoding="utf-8") as file:
        file.write(cleaned_content)

# Use the function
text_file_path = 'J American Geriatrics Society - 2019 - .txt'
remove_spaces(text_file_path)

# If you want to save the cleaned content to a new file:
cleaned_file_path = "test1.txt"
with open(text_file_path, "r", encoding="utf-8") as file:
    cleaned_content = file.read()

with open(cleaned_file_path, "w", encoding="utf-8") as file:
    file.write(cleaned_content)

