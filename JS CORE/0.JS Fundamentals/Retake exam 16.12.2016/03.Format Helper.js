function formatHelper(input) {
    let text = input[0];

    //1 fix single space after .,!?:;

    //if theres 2 or more spaces
    let singleSpaceRegex1 = /([.,:;?!])([ ]{2,})/g;
    function singleSpaceReplacer(match, p1) {
        return p1.trim();
    }
    text = text.replace(singleSpaceRegex1,singleSpaceReplacer);

    //if theres no spaces but sth else
    let singleSpaceRegex2 = /([.,:;?!])([\S])/g;
    text = text.replace(singleSpaceRegex2,(match,p1,p2)=>{
        let singleSpace = p1 + " " + p2;
        return singleSpace;
    });

    //2 fix preceding whitespaces
    let precedingSpaceRegex = /(\s)+([.,!?:;])/g;
    text = text.replace(precedingSpaceRegex,(match,p1,p2)=>{
        return p2;
    });

    //3 ellipsis regex
    let ellipsisRegex = /(\.\s*\.\s*\.\s*!)/g
    text = text.replace(ellipsisRegex,(match,p1)=>{
        return " ...!";
    });

    //4 dates
    let dotDigitRegex = /(\.) +(\d+)/g;
    text = text.replace(dotDigitRegex,(match,p1,p2) =>{
        return p1 + p2;
    });

    //5 fix quote trimming

    let quoteRegex = /"(.+)"/g;
    function quoteReplacer(match,p1) {
        let quotation = '\"' + p1.trim() + '\"';
        return quotation;
    }
    text = text.replace(quoteRegex,quoteReplacer);

    console.log(text);
}

// formatHelper([
//     'Terribly formatted text . . . ! With chaotic spacings  ." Terrible quoting "! Also this date is pretty confusing : 20 . 12. 16 .'
// ]);

let myTest =
    'Why is this so Stupid   ?! Man dont care bout anything else on   : 20    .   12 .      16    .    I keep it 100 ! "  Damn man .    .    .    !   "  sayed he .    picks'

formatHelper([myTest]);