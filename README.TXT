By Ziwei (Cheemay) Song

Please download the folder "source code". This folder contains all the necessary code and files.

The extraction algorithms are for Table 2 and Table 4 of the Beers Criteria.
These algorithms are called "table2.py" for Table 2 and "table4.py" for Table.

Prior to the extraction algorithms, the Beers Criteria have already been rotated based on table and page orientation, 
separated based on page numbers and converted to text file.

rotate.py:
This code rotates the manually selected pages of the Beers Criteria from portrait page orientation to landscape page orientation

print.py:
This code separates the Beers Criteria tables into their respective PDF files

table2.py:
- To run: Run py .\table2.py when in correct directory
- This code is for the extraction of Table 2 of the Beers Criteria.
- Please uncomment lines from 397-402 and input name of the file for the data to be extracted from the Beers Criteria.
    - On line 400; change the list to desired heading to see the list.
        - Choose from organ_list, cat_list, drug_list, rat_list, rec_list, evi_result_list or str_result_list
            - organ_list is for Organ System list
            - cat_list is for Therapeutic Category list
            - drug_list is for Drug(s) list
            - rat_list is for Rationale list
            - rec_list is for Recommendation list
            - evi_result_list is for Quality of Evidence list
            - str_result_list is for Strength of Recommendation list

table4.py:
- To run: Run py .\table4.py when in correct directory
- This code is for the extraction of Table 4 of the Beers Criteria.
- Please uncomment lines from 174-179 and input name of the file for the data to be extracted from the Beers Criteria.
    - On line 177; change the list to desired heading to see the list.
        - Choose from organ_list, cat_list, drug_list, rat_list, rec_list, evi_result_list or str_result_list
            - organ_list is for Organ System list
            - cat_list is for Therapeutic Category list
            - drug_list is for Drug(s) list
            - rat_list is for Rationale list
            - rec_list is for Recommendation list
            - evi_result_list is for Quality of Evidence list
            - str_result_list is for Strength of Recommendation list

