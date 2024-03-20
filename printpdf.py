#STEP 2: SEPARATE THE PAGES BASED ON BEERS TABLES INTO DIFFERENT FILESs

import PyPDF2

# define page ranges and name output file names for each table
page_ranges = [
    (1, 5, "table_2.pdf"),
    (6, 8, "table_3.pdf"),
    (9, 9, "table_4.pdf"),
    (10, 11, "table_5.pdf"),
    (12, 13, "table_6.pdf")
]

# input PDF file name
input_pdf_filename = "beers_tables.pdf"

with open(input_pdf_filename, "rb") as pdf_file:
    pdf_reader = PyPDF2.PdfReader(pdf_file)

    for start_page, end_page, output_filename in page_ranges:
        pdf_writer = PyPDF2.PdfWriter()

        for page_num, page in enumerate(pdf_reader.pages):
            if start_page <= page_num + 1 <= end_page:
                pdf_writer.add_page(page)

        # save the output PDF file
        with open(output_filename, "wb") as output_file:
            pdf_writer.write(output_file)
