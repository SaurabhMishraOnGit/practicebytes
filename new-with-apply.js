const construct = (Class, ...args) => new Class(...args);

console.log(construct(Array, 5));