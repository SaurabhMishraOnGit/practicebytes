function prefill(n, v) {

var str = Math.floor(Number(n));
if(isNaN(str))
throw new TypeError (n +" is invalid");
 var arr=[]
 for (let i = 0; i < n; i = i + 1) {
   arr.push(v);
}
return arr;

}
