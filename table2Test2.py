import re

organ_list = []
cat_list = []
drug_list = []
rat_list = []
rec_list = []
evi_list = []
str_list = []

current_line1 = ""
current_line2 = ""
current_line3 = ""
current_line4 = ""
current_line5 = ""

# an attempt again to try correspond 'headings' to another as you run through the file
# proved to be difficult and inefficient

lines1 = []
current_line1 = ""
TC_to_OS = {}
OS_to_TC = {}
with open("table2Text.txt", "r", encoding="utf-8") as file:
    for line in file: # getting category list for category dictionary
        #get OS 
        if line.startswith(" " * 6) and line[6:7] != " ": # if line starts with 6 spaces in and the space indent 6 or 7 is not a space
            # split the line into words
            words = line.strip().split()
            # concatenate words with more than one character and add to the organ list
            #organ_list.append(' '.join(word for word in words if len(word) > 1))

        elif line.startswith(" " * 7) and line[7:8] != " ": # if line starts with 7 spaces in and the space indent 7 or 8 is not a space
            # split the line into words
            words = line.strip().split()
            # concatenate words with more than one character and add to the organ list
            #organ_list.append(' '.join(word for word in words if len(word) > 1)) 
        current_OS = words
        # OS_to_TC[current_OS] = [] #should be empty list
        #print(current_OS)

        #get TC

        # if line starts with 9 or 10 spaces in and NOT 11 spaces in
        if (line.startswith(" " * 9) or line.startswith(" " * 10)) and not line.startswith(" " * 11): 
            # in the case that the line is 9 spaces in and exactly 9 spaces, the character is lowercase or starts with '('
            if line.startswith(" " * 9) and current_line1 and (line[9:10].islower() or line[9:10] == '('):
                # concatenate lines starting with lowercase to the previous line
                current_line1 += " " + line[9:62].strip()
            elif line.startswith(" " * 10) and current_line1 and (line[10:11].islower() or line[10:11] == '('):
                current_line1 += " " + line[10:62].strip()
            else:
                # Store the current line
                if current_line1:
                    lines1.append(current_line1)
                if(len(current_line1) > 0):
                    # print("Current_OS =")
                    # print(current_OS)
                    # # print("Current_1 =")
                    # print(current_line1)
                    # print("\n")
                    OS = current_OS[0]
                    TC = "".join(current_line1)
                    TC_to_OS[TC] = OS
                    # OS_to_TC[OS].append(TC)
                current_line1 = line[9:61].strip()

    # Add the last line if it exists
    if current_line1:
        lines1.append(current_line1)
    # print("Lines1 =")
    # print(lines1)
    # print("\n")
    # Process the lines and create the organ_list
    for line in lines1:
        words = line.split()
        #print(words)
        cat_list.append(' '.join(word for word in words if len(word) > 1))
    

    print("TC_to_OS")
    for k, v in TC_to_OS.items():
        print(v, k)


    # Create the organ_dict
    # cat_dict = {str(i): value for i, value in enumerate(cat_list)}
    #print(cat_list)

    # this is needed to close an reopen the same file
    file.seek(0)

    # get Drugs
    lines2 = []
    for line in file:
        # check if the line meets the criteria for indentation and length
        if (line.startswith(" " * 11) or line.startswith(" " * 12)) or line.startswith(" " * 13) and not line.startswith(" " * 14):
            # if meet any of the requirement then concatenate lines starting with lowercase to the previous line
            if line.startswith(" " * 11) and current_line2 and (line[11:12].islower() or line[11:12] == '('):
                current_line2 += " " + line[11:62].strip()
            # exactly 12 spaces in
            elif line.startswith(" " * 12) and current_line2 and (line[12:13].islower() or line[12:13] == '('):
                current_line2 += " " + line[12:62].strip()
            # exactly 13 spaces in
            elif line.startswith(" " * 13) and current_line2 and (line[13:14].islower() or line[13:14] == '('):
                current_line2 += " " + line[13:62].strip()
            # exactly 14 spaces in
            elif line.startswith(" " * 14) and current_line2 and (line[14:15].islower() or line[14:15] == '('):
                current_line2 += " " + line[14:62].strip()
            else:
                # store the current line
                if current_line2:
                    lines2.append(current_line2)
                current_line2 = line[11:61].strip()

    # add the last line if it exists
    if current_line2:
        lines2.append(current_line2)

    # process the lines and create the drug list
    for line in lines2:
        words = line.split()
        drug_list.append(' '.join(word for word in words if len(word) > 1))

    # this is needed to close an reopen the same file
    file.seek(0)
    
    # get Rationale
    lines3 = []  # store lines with the specified conditions
    for line in file:
        indentated_line = line[61:126]
        # check if the line starts with a space
        if not indentated_line.strip():
            continue  # ignore lines that start with only spaces

        # find the first non-space character in the line and can't find it then set to None
        # first_char is set to be the first non-space character
        first_char = next((char for char in indentated_line if not char.isspace()), None)

        # check if the first non-space character is lowercase
        if first_char and first_char.islower() or first_char in ('(', '<', '-'):
            # concatenate with a space to the previous line
            current_line3 += " " + indentated_line.strip()
        else:
            # if the line starts with an uppercase letter or is empty, store the previous line
            if current_line3:
                lines3.append(current_line3.strip())
            # reset the current line
            current_line3 = indentated_line.strip()

    # add the last line to the list
    if current_line3:
        lines3.append(current_line3.strip())          

    # process the lines and create the rationale list
    for line in lines3:
        words = line.split()
        rat_list.append(' '.join(word for word in words if len(word) > 1))

    # necessary modifications in order to concatenate lines together
    # so for example there are two lines that start with a capital letter but it concatenates current line to previous line
    # if the current line starts with a lowercase letter
    rationale_replace1 = rat_list[0] + "\n" + rat_list[1]
    rat_list[0] = rationale_replace1
    del rat_list[1]
    rationale_replace2 = rat_list[10] + "\n" + rat_list[11] + "\n" + rat_list[12]
    rat_list[10] = rationale_replace2
    del rat_list[11:13]
    rationale_replace3 = rat_list[14] + "\n" + rat_list[15]
    rat_list[14] = rationale_replace3
    del rat_list[15]
    rationale_replace4 = rat_list[16] + "\n" + rat_list[17]
    rat_list[16] = rationale_replace4
    del rat_list[17]
    rationale_replace5 = rat_list[22] + "\n" + rat_list[23]
    rat_list[22] = rationale_replace5
    del rat_list[23]
    rationale_replace6 = rat_list[24] + "\n" + rat_list[25]
    rat_list[24] = rationale_replace5
    del rat_list[25]
    rationale_replace7 = rat_list[27] + "\n" + rat_list[28]
    rat_list[27] = rationale_replace7
    del rat_list[28]
    rationale_replace8 = rat_list[32] + " \n" + rat_list[33] + "\n" + rat_list[34]
    rat_list[32] = rationale_replace8
    del rat_list[33:35]
    rationale_replace9 = rat_list[33] + "\n" + rat_list[34]
    rat_list[33] = rationale_replace9
    del rat_list[34]

    # this is needed to close an reopen the same file
    file.seek(0)

    # get Recommendation
    lines4 = []  # store lines with the specified conditions
    for line in file:
        indentated_line = line[125:181]

        # check if the line starts with a space
        if not indentated_line.strip():
            continue  # ignore lines that start with only spaces

        # find the first non-space character in the line and can't find it then set to None
        # first_char is set to be the first non-space character
        first_char = next((char for char in indentated_line if not char.isspace()), None)

        # check if the first non-space character is lowercase
        if first_char and first_char.islower():
            # concatenate with a space to the previous line
            current_line4 += " " + indentated_line.strip()
        else:
            # if the line starts with an uppercase letter or is empty, store the previous line
            if current_line4:
                lines4.append(current_line4.strip())
            # reset the current line
            current_line4 = indentated_line.strip()

    # add the last line to the list
    if current_line4:
        lines4.append(current_line4.strip())          

    # process the lines and create the recommendation list
    for line in lines4:
        words = line.split()
        # necessary modifications: these specific 'words' are excluded from extraction process
        highlights_words = ['Moderate', 'High', 'Low', 'Atri', 'He']
        #print(words)
        words1 = [word for word in words if len(word) > 1 and word not in highlights_words]
        rec_list.append(' '.join(words1))

    recommendation_replace1 = rec_list[10] + "\n" + rec_list[11] + "\n" + rec_list[12]
    rec_list[10] = recommendation_replace1
    del rec_list[11:13]

    # needed to close file and reopen again
    file.seek(0)

    # get Quality of Evidence & Strength of Recommendation
    lines5 = []  # store lines with the specified conditions
    # keep_words and remove_words needed to detect which lines to keep or remove
    keep_words = ['low', 'strong', 'moderate', 'high', 'or', 'cream', 'tablets:', 'weak', '>0.125 mg/day:']
    remove_words = ['ts:', 'due to', '12 weeks', '(eg oral', 'ID use)', 'ndition or', 'ure of drug']
    previous_first_word = None
    previous_line = ""
    for line in file:
        indentated_line = line[170:]
        # this removes single letter words, commas, dashes, trailing whitespaces, trademarks (these are in pdf)
        indentated_line = re.sub(r'\b\w\b|,|–|\s+$|®', '', indentated_line)

        if not indentated_line.strip() or len(indentated_line.strip()) == 1:
            continue  # ignore lines that start with only spaces or contain only one character

        # check if the line contains only lowercase characters, excluding keep_words
        if all(char.islower() or any(keyword in char for keyword in keep_words) for char in indentated_line.strip()):
            continue

        # check if any complete word from remove_words is present in the line
        if any(f' {keyword} ' in f' {indentated_line} ' for keyword in remove_words):
            continue

        # remove part before the first uppercase letter
        match = re.search('[A-Z]', indentated_line)
        if match:
            indentated_line = indentated_line[match.start():]

        # split the line into two words based on the specified criteria
        words = re.split(r'\s{3,}', indentated_line.strip(), maxsplit=1)
        if len(words) == 2:
            first_list = list(words[:1])
            second_list = list(words[1:])

        evi_list.append(first_list[0])
        str_list.append(second_list[0])

    evi_result_list = []
    str_result_list = []
    current_phrase = ""
    current_phrase1 = ""

    for word in evi_list:
        if current_phrase and (word.islower() or word.startswith('>')):
            current_phrase += ' ' + word
        else:
            if current_phrase:
                evi_result_list.append(current_phrase.strip())
                current_phrase = ""
            current_phrase = word

    if current_phrase:
        evi_result_list.append(current_phrase.strip())

    # modications here as some lines needed to be connected
    evi_result_list[25] += " moderate"
    evidence_replace1 = evi_result_list[10] + "\n" + evi_result_list[11] + "\n" + evi_result_list[12]
    evi_result_list[10] = evidence_replace1
    del evi_result_list[11:13]
    evidence_replace2 = evi_result_list[22] + "\n" + evi_result_list[23]
    evi_result_list[22] = evidence_replace2
    del evi_result_list[23]

    for word in str_list:
        if current_phrase1 and (word.islower() or word.startswith('>')):
            current_phrase1 += ' ' + word
        else:
            if current_phrase1:
                str_result_list.append(current_phrase1.strip())
                current_phrase1 = ""
            current_phrase1 = word

    if current_phrase1:
        str_result_list.append(current_phrase1.strip())

    # lines are needed to be connected
    strength_replace1 = str_result_list[10] + "\n" + str_result_list[11] + "\n" + str_result_list[12]
    str_result_list[10] = strength_replace1
    del str_result_list[11:13]
    strength_replace2 = str_result_list[22] + "\n" + str_result_list[23]
    str_result_list[22] = strength_replace2
    del str_result_list[23]