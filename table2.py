import os
import camelot
import pandas as pd
import re

try:
    folderName = "beers_pdfs2019"
    fileName = "table_2.pdf"

    pdf_file = os.path.join(folderName, fileName)

    full_table = []

    tables = camelot.read_pdf(pdf_file, pages='all', flavor='stream', row_tol=10, split_text=True, debug=True)

    pattern = r"Table 2 \(Contd\.\)"
    keywords = ['Organ', 'System', 'Therapeutic', 'Category', 'Drug(s)', 'Rationale', 'Recommendation', 'Quality of', 'Evidence', 'Strength of', 'Recommendation']

    for table in tables:
        table_df = table.df

        if table_df.shape[1] > 5:
            # trim the DataFrame to 5 columns
            table_df = table_df.iloc[:, :5]

        # remove rows with "Table 2 (Contd.)" in the first column
        table_df = table_df[~table_df.iloc[:, 0].str.contains(pattern, case=False, na=False, regex=False)]

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

        # extract only the word 'Strong' from the last column using a regular expression
        table_df.iloc[:, -1] = table_df.iloc[:, -1].str.extract(r'(Strong)', flags=re.IGNORECASE, expand=False)

        # replace NaN values with an empty string or any other desired placeholder
        table_df.iloc[:, -1] = table_df.iloc[:, -1].fillna('')

    # append the processed DataFrame to the list
        full_table.append(table_df)

    # concatenate all DataFrames in the list after processing all tables
    final_result = pd.concat(full_table, ignore_index=True)

    # could name the coloumns
    # final_result.columns = ['Organ System, Therapeutic Category, Drug(s)', 'Rationale', 'Recommendation', 'Quality of Evidence', 'Strength of Recommendation']

    print(final_result)

except Exception as e:
    print(f"Error occurred: {str(e)}")
