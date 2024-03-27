# THIS WAS AN ATTEMPT TO USE PDFMiner FOR EXTRACTION

from pdfminer.high_level import extract_text

text = extract_text("beers_tables.pdf")

# remove line breaks from the extracted text
with open("test.txt", "w", encoding="utf-8") as file:
    file.write(text)
