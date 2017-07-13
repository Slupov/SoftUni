function palindrome(input) {
    let isPalindrome = true;
    let inputAr = input[0].split('');
    for (let i = 0; i < inputAr.length; i++) {
        if (inputAr[i] != inputAr[inputAr.length - 1 - i]) {
            isPalindrome = false;
        }
    }

    return isPalindrome;
}