import os
import camelot
import pandas as pd
import re

from pymongo import MongoClient
from connect import database

# current progress: table 2
# first attempt at trying to extract table 2 of beers criteria using 'Camelot'
# did not work as intended

try:

    client = MongoClient(database['url'])
    db = client['Beers_2019']

    collection_name = 'Table2'
    collection = db[collection_name]


    folderName = "beers_pdfs2019"
    fileName = "table_2.pdf"

    pdf_file = os.path.join(folderName, fileName)

    full_table = []

#    tables = camelot.read_pdf(pdf_file, pages='all', flavor='stream', row_tol=10, split_text=True, debug=True)
    tables = camelot.read_pdf(pdf_file, pages='all', flavor='stream', row_tol=11, debug=True)

    pattern = r"Table 2 \(Contd\.\)"
    keywords = ['Organ', 'System', 'Therapeutic', 'Category', 'Drug(s)', 'Rationale', 'Recommendation', 'Quality of', 'Evidence', 'Strength of', 'Recommendation']

    for table in tables:
        table_df = table.df

        if table_df.shape[1] > 5:
            # trim the DataFrame to 5 columns
            table_df = table_df.iloc[:, :5]

        # remove rows with "Table 2 (Contd.)" in the first column
        #table_df = table_df[~table_df.iloc[:, 0].str.contains(pattern, case=False, na=False, regex=False)]

        # initialize a variable to track the previous row index
        prev_row_index = None

        # iterate through the rows and check for specified keywords
        for index, row in table_df.iterrows():
            has_keyword = any(keyword in cell for keyword in keywords for cell in row)

            if has_keyword or (prev_row_index is not None and prev_row_index == index - 1):
                # delete the current row and the one above it
                table_df = table_df.drop(index)
                if prev_row_index is not None:
                    table_df = table_df.drop(prev_row_index)
                prev_row_index = None
            elif has_keyword:
                prev_row_index = index

        # reset the index after deleting rows
        table_df = table_df.reset_index(drop=True)

        # Modify the cell in the 0th row and 0th column -> for the b superscript
        cell_to_modify = table_df.iloc[0, 0]
        if isinstance(cell_to_modify, str):
            table_df.iloc[0, 0] = cell_to_modify[:-1]
        elif pd.notna(cell_to_modify):
            table_df.iloc[0, 0] = str(cell_to_modify)[:-1]

        # extract only the word 'Strong' from the last column using a regular expression
        table_df.iloc[:, -1] = table_df.iloc[:, -1].str.extract(r'(Strong)', flags=re.IGNORECASE, expand=False)

        # replace NaN values with an empty string or any other desired placeholder
        table_df.iloc[:, -1] = table_df.iloc[:, -1].fillna('')

        # append the processed DataFrame to the list
        full_table.append(table_df)

    # concatenate all DataFrames in the list after processing all tables
    final_result = pd.concat(full_table, ignore_index=True)

    # could name the coloumns
    final_result.columns = ['Organ System, Therapeutic Category, Drug(s)', 'Rationale', 'Recommendation', 'Quality of Evidence', 'Strength of Recommendation']
    #final_result.columns = ['Organ System']
    #firstCol = final_result.iloc[:, 0].to_string(index=True)
    text_representation = final_result.to_string(index=True)

    # if collection.count_documents({}) == 0:

    #     data_dict = final_result.to_dict(orient='records')
    #     data_dict = [{str(key): value for key, value in doc.items()} for doc in data_dict]
    #     collection.insert_many(data_dict)
        
    print(text_representation)
    # print(final_result)

except Exception as e:
    print(f"Error occurred: {str(e)}")
