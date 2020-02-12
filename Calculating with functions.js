const helper = (number, operation) => (!operation ? number : operation(number));

const zero = operation => helper(0, operation);
const one = operation => helper(1, operation);
const two = operation => helper(2, operation);
const three = operation => helper(3, operation);
const four = operation => helper(4, operation);
const five = operation => helper(5, operation);
const six = operation => helper(6, operation);
const seven = operation => helper(7, operation);
const eight = operation => helper(8, operation);
const nine = operation => helper(9, operation);

const plus = a => b => a + b;
const minus = a => b => b - a;
const times = a => b => a * b;
const dividedBy = a => b => Math.floor(b / a);

console.log(two(plus(one())));
console.log(five(times(three())));
console.log(four(minus(three())));
console.log(seven(dividedBy(three())));
console.log(six(plus(zero())));
console.log(eight(times(nine())));