function censorship(input) {
    RegExp.escape = function (s) {
        return s.replace(/[-\/\\^$*+?.()|[\]{}]/g, '\\$&');
    }
    let text = input[0];
    let words = input.slice(1).map(RegExp.escape).join("|");
    let regex = new RegExp(words, 'g');
    text = text.replace(regex, w => '-'.repeat(w.length));
    return text;
}