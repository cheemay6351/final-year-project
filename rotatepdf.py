import PyPDF2
import os

# select the pages to rotate and leave the other pages the same (unrotated)
rotate_pages = [5, 6, 7, 8, 9, 10, 11, 12, 14, 15]
org_pages = [13, 16, 17]

folderName = "beers_pdfs2019"
fileName = "J American Geriatrics Society - 2019 - .pdf"

pdf_file = os.path.join(folderName, fileName)

with open(pdf_file, "rb") as pdf_file:
    pdf_reader = PyPDF2.PdfReader(pdf_file)

    pdf_writer = PyPDF2.PdfWriter()

    for page_num, page in enumerate(pdf_reader.pages):
        if page_num + 1 in rotate_pages:
            page.rotate(90)
            pdf_writer.add_page(page)
        if page_num + 1 in org_pages:
            pdf_writer.add_page(page)

    output_filename = "output2.pdf"
    with open(output_filename, "wb") as output_file:
        pdf_writer.write(output_file)