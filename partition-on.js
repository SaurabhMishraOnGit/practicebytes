  function partitionOn(pred, items) {
    var sp_idx = 0;
    for(var i in items) {
      if(!pred(items[i])) {
        // If the predicate is false, move it to sp_idx, otherwise, leave it.
        items.splice((sp_idx++), 0, items.splice(i, 1)[0]);
      }
    }
    return sp_idx;
  }