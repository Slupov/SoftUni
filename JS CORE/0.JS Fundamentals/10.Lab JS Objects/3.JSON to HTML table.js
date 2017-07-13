function solve ([json]) {
  let inputArr = JSON.parse(json)
  let html = '<table>\n'
  html += '  <tr>'
  for (let key of Object.keys(inputArr[0])) {
    html += `<th>${htmlEscape(key)}</th>`
  }
  html += '</tr>\n'

  for (let object of inputArr) {
    html += '  <tr>'
    for (let key of Object.keys(object)) {
      html += `<td>${htmlEscape(object[key] + '')}</td>`
    }
    html += '</tr>\n'
  }
  html += '</table>'

  console.log(html)

  function htmlEscape (text) {
    return text.replace(/&/g, '&amp;')
      .replace(/</g, '&lt;')
      .replace(/>/g, '&gt;')
      .replace(/"/g, '&quot;')
      .replace(/'/g, '&#39;')
  }
}
