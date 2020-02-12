function countWords(str) {
str=str.trim()
if(str=="")
return 0;
else
{
  st=str.replace(/[^\S+$]/g,' ');
  str= str.replace(/[^a-zA-Z0-9-'` ]/g, ' ');
  return str.trim().split(/\s+/).length;
}

}
