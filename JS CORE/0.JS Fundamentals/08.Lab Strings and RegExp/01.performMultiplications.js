function performMultiplications([text]) {
    text = text.replace(/(-?\d+)\s*\*\s*(-?\d+(\.\d+)?)/g,
        (match, num1, num2) => Number(num1) * Number(num2));
    //num1 and num2 are the groups in the regex while match is the matched substring in the text
    console.log(text);
}