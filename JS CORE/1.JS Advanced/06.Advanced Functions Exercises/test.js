let b = -5;

function add(a) {
    b+=a;
    console.log("a -> " + a);
    console.log(b);
    return add(a+2)
};

add(5);
