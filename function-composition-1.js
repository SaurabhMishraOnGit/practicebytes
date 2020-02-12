function compose(...item) {
    return function(items) {
        return item.reduceRight((accumulator, element) => element(accumulator), items);
    }
}