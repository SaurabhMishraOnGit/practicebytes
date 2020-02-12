// isSantaClausable(santa); // must return TRUE
// isSantaClausable(notSanta); // must return FALSE
const notSanta = {
  sayHoHoHo: () => { console.log('Oink Oink!'); },
  // no distributeGifts() and no goDownTheChimney()
};
const santa = {
  sayHoHoHo: () => { console.log('Ho Ho Ho!'); },
  distributeGifts: () => { console.log('Gifts for all!'); },
  goDownTheChimney: () => { console.log('*whoosh*'); },
};


const isSantaClausable = obj => ['sayHoHoHo', 'distributeGifts', 'goDownTheChimney'].every(
  methodName => typeof obj[methodName] === 'function',
);

console.log(isSantaClausable(notSanta));
console.log(isSantaClausable(santa));