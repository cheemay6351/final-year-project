import re

def table2Clean(file_path, start_line, end_line):
    with open(file_path, 'r', encoding="utf-8") as file:
        lines = file.readlines()

        # list of keywords that are unnecessary
        keywords = ['Organ System, Therapeutic Category, Drug(s)', 'Rationale', 'Recommendation', 'Quality of', 'Strength of', 'Table 2  (Contd.)', '(Continued)']

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
        new3_lines = [line for line in new2_lines if len(line.strip()) > 1]

        with open('table2Text.txt', 'w', encoding="utf-8") as file:
            for line in new3_lines:
                file.write(line) # write line to file

file_path = 'table_2.txt'
start_line = 11 # start line number; 11
end_line = 915 # end line number; 915
table = table2Clean(file_path, start_line, end_line)