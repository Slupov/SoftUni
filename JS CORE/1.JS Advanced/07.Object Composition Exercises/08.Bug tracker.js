function bugTracker() {
    // Set { Number ID => Set { type Object OBJECT => type Object JQUERYOBJECT }
    let bugs = new Map();
    let id = 0;
    // keeps track of the selectors
    let parents = [];
    // keeps the last main function?
    // no idea why it gets lost somewhere in the processing
    let lastMain = [];

    function setLatestID() {
        return id++;
    }

    function getLatestID() {
        return Math.max(0, id - 1);
    }

    function update(parent, main) {
        // main is the main function
        if (lastMain[lastMain.length - 1] != main && main != undefined)
            lastMain.push(main);
        if (main == undefined) main = lastMain[lastMain.length - 1];
        if (parent == undefined || parent == '') parent = parents[parents.length - 1];
        console.log(parents);
        main.output(parent);
    }

    function jqueryTemplate(id, author, description, severity, status) {
        if (status === undefined) status = 'Open';
        return $(`<div id="report_${id}" class="report">
                        <div class="body">
                            <p>${description}</p>
                        </div>
                        <div class="title">
                            <span class="author">Submitted by: ${author}</span>
                            <span class="status">${status} | ${severity}</span>
                        </div>
                    </div>`);
    }

    return {
        report: function (author, description, reproducible, severity) {
            let obj = {
                id: setLatestID(),
                author: author,
                description: description,
                reproducible: reproducible,
                severity: severity,
                status: 'Open'
            };

            let jqueryObj = jqueryTemplate(getLatestID(), author, description, severity);
            bugs.set(getLatestID(), new Map());
            bugs.get(getLatestID()).set(obj, jqueryObj);
            update('', this);
        },

        setStatus: function (id, newStatus) {
            let obj, jqueryObj;
            for ([obj, jqueryObj] of bugs.get(id)) {
                obj.status = newStatus;
                jqueryObj = jqueryTemplate(obj.id, obj.author, obj.description, obj.severity, obj.status);
                bugs.get(id).clear();
            }
            bugs.get(id).set(obj, jqueryObj);
            update('', this);
        },

        remove: function (id) {
            bugs.delete(id);
            update('', this);
        },

        output: function (selector) {
            parents.push(selector);
            if (bugs.size > 0)
                $(selector).empty();
            for (let bugID of bugs) {
                for (let [obj, jqueryObj] of bugID[1])
                    $(jqueryObj).appendTo(selector);
            }
        },

        sort: function (method) {
            // the sorting made in this switch
            // is possible because sort is a recursive
            // function that on each recursion iterates one next place
            // while it remembers the last place it was on
            // on each of the input values. In this case a, b
            let objA, jqueryObjectA, objB, jqueryObjectB;
            method = (method + '').toLowerCase();
            switch (method) {
                case 'author':
                    bugs = new Map([...bugs.entries()].sort(function (a, b) {
                        for ([objA, jqueryObjectA] of a[1])
                            for ([objB, jqueryObjectB] of b[1])
                                return objA.author.localeCompare(objB.author);
                    }));
                    update('', this);
                    break;
                case 'severity':
                    bugs = new Map([...bugs.entries()].sort(function (a, b) {
                        for ([objA, jqueryObjectA] of a[1])
                            for ([objB, jqueryObjectB] of b[1])
                                return objA.severity - objB.severity;
                    }));
                    update();
                    break;
                default:
                    bugs = new Map([...bugs.entries()].sort(function (a, b) {
                        for ([objA, jqueryObjectA] of a[1])
                            for ([objB, jqueryObjectB] of b[1])
                                return objA.id - objB.id;
                    }));
                    update('', this);
                    break;
            }
        }
    }
};