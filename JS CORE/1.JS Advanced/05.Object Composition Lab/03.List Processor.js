function listProcessor(input) {
    let commandProcessor = (function() {
        let list = [];
        return {
            add: (newItem) => list.push(newItem),
            remove: (item) =>
                list = list.filter(x => x != item),
            print: () => console.log(list.join(","))
        }
    })();

    for (let command of input) {
      let [cmdName, arg] = command.split(" ");
        commandProcessor[cmdName](arg);
    }
}
