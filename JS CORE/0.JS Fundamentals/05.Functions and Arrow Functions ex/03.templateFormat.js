function templateFormat(input) {
    let string = `<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n<quiz>\n  `;
    for (let i = 0; i < input.length; i += 2) {
        let question = input[i];
        let answer = input[i + 1];
        string += `    <question>\n${question}\n  </question>\n  <answer>\n    ${answer}\n  </answer>\n`
    }
    string += `</quiz>`;
    return string;
}