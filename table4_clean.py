import re

def table2Clean(file_path, start_line, end_line):
    with open(file_path, 'r', encoding="utf-8") as file:
        lines = file.readlines()

        # list of keywords that are unnecessary
        keywords = ['Drug(s)', 'Rationale', 'Recommendation', 'Quality of', 'Strength of']

        # ensure start_line and end_line are within bounds
        if start_line < 0 or start_line >= len(lines) or end_line < start_line or end_line >= len(lines):
            print("Invalid start or end line values.")
            return

        # remove lines that contains any of the listed keywords
        lines = [line for line in lines[start_line:end_line + 1] if not any(keyword in line for keyword in keywords)]

        # remove lines that are blank or empty
        new_lines = [line for line in lines if line.strip()]

        # remove lines that contains any single character
        new2_lines = [line for line in new_lines if len(line.strip()) > 1]

        with open('table4Text.txt', 'w', encoding="utf-8") as file:
            for line in new2_lines:
                file.write(line) # write line to file

file_path = 'table_4.txt'
start_line = 94 # start line number; 95
end_line = 530 # end line number; 530
table = table2Clean(file_path, start_line, end_line)