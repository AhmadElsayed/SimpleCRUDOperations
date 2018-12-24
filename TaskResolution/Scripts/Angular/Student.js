var Student = {
    getEmpty: function () {
        return {
            id: -1,
            number: 0,
            firstname: null,
            midname: null,
            lastname: null,
            birthdate: '01/01/1990',
            subjects: []
        };
    },
    clone: function (student) {
        var newObj = JSON.parse(JSON.stringify(student));
        newObj.birthdate = new Date(newObj.birthdate);
        return newObj;
    }
}