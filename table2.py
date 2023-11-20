import re

def read_and_print(file_path, start_line, end_line):
    with open(file_path, 'r', encoding="utf-8") as file:
        lines = file.readlines()

        # list of keywords that are unnecessary
        keywords = ['Organ System, Therapeutic Category, Drug(s)', 'Rationale', 'Recommendation', 'Quality of', 'Evidence', 'Strength of', 'Table 2  (Contd.)', '(Continued)']

        # ensure start_line and end_line are within bounds
        if start_line < 0 or start_line >= len(lines) or end_line < start_line or end_line >= len(lines):
            print("Invalid start or end line values.")
            return

        # remove lines that begin with any character and have no indentations
        lines = [line for line in lines[start_line:end_line + 1] if not line.strip() or line.lstrip()[0] != line[0]]

        # remove lines that contains any of the listed keywords
        new_lines = [line for line in lines[start_line:end_line + 1] if not any(keyword in line for keyword in keywords)]

        # remove lines that are blank or empty
        new2_lines = [line for line in new_lines if line.strip()]

        # remove lines that contains any single character
        filtered_lines = [line for line in new2_lines if len(line.strip()) > 1]

        # print the selected lines
        for line in filtered_lines:
            print(line, end='')

        # return the selected lines as a list
        return filtered_lines

file_path = 'table_2.txt'
start_line = 11 # playing with start line number; 11
end_line = 915 # end line number; 915
table = read_and_print(file_path, start_line, end_line)

# def read_and_print(file_path, start_line):
#     with open(file_path, 'r', encoding="utf-8") as file:
#         lines = file.readlines()

#         # Ensure start_line is within bounds
#         if start_line < 0 or start_line >= len(lines):
#             print("Start line is out of bounds.")
#             return

#         # Iterate over lines starting from the specified line
#         first_line = lines[start_line]
#         all_lines = ''
#         for i in range(start_line, len(lines)):
#             line = lines[i+1]

#             # Check if the line starts with 6 spaces
#             if line.startswith("      ") and line[6:7] != " ":  # Adjust the number of spaces as needed
#                 break  # Stop when a line with 6 spaces indent is detected
            
#             all_lines += line
        
#         table = first_line + all_lines
#         return table

# # Example usage
# file_path = 'table_2.txt'
# start_line = 22  # Replace with the desired starting line
# table = read_and_print(file_path, start_line)

# print(table)