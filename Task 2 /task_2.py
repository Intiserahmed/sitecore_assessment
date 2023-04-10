def is_palindrome_with_trash_symbols(input_string, trash_symbols_string):
    # convert to lowercase for case-insensitivity
    input_string = input_string.lower()
    # convert to set for faster lookup
    trash_symbols_set = set(trash_symbols_string.lower())
    left = 0  # initialize left pointer to the leftmost character of the input string
    # initialize right pointer to the rightmost character of the input string
    right = len(input_string) - 1

    while left < right:  # continue checking until pointers cross or non-palindromic pair is found
        # skip over trash symbols on left side
        while input_string[left] in trash_symbols_set:
            left += 1
        # skip over trash symbols on right side
        while input_string[right] in trash_symbols_set:
            right -= 1
        if input_string[left] != input_string[right]:  # non-palindromic pair found
            return False
        left += 1  # move left pointer one step to the right
        right -= 1  # move right pointer one step to the left

    return True  # input string is palindrome with trash symbols ignored
