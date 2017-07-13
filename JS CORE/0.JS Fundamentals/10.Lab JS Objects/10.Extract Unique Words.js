function extractUniqueWords(input) {
    let set = new Set();
    for (let sentence of input) {
        sentence = sentence.toLowerCase();
        let words = sentence.split(/[^A-Za-z]+/g).filter(x=>x != "");
        for (let word of words) {
          set.add(word);
        }
    }
    let output = "";
    for (let word of set) {
      output+= word + ", "
    }
    output = output.substring(0,output.length-2);
    return output;
}