from pdfminer.high_level import extract_text

# text = extract_text("J American Geriatrics Society - 2023 - .pdf")

text = extract_text("output.pdf")

# remove line breaks from the extracted text

with open("test.txt", "w", encoding="utf-8") as file:
    file.write(text)
