// return a function that returns n
function always (n) {
    return function( val) {
       val=n;
       return val;
    }
}
