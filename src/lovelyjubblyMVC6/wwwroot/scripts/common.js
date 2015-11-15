//COMMON JAVASCRIPT FUNCTIONS
define('common', function () {

    convertUTCToDDMMYYYY = function (d) {
        date = new Date(d);
        var dd = date.getDate();
        var mm = date.getMonth() + 1;
        var yyyy = date.getFullYear();
        if (dd < 10) {
            dd = '0' + dd;
        }
        if (mm < 10) {
            mm = '0' + mm;
        }
        ;
        return d = dd + '/' + mm + '/' + yyyy;
    };

    //calculate qb rating
    calculateQBRating = function(completion, gain, touchdown, interception) {

        var rating;

        completion = ((completion - 30) * 0.05);

        if (completion < 0) {
            completion = 0;
        }

        if (completion > 2.375) {
            completion = 2.375;
        }

        gain = ((gain - 3) * 0.25);

        if (gain < 0) {
            gain = 0;
        }

        if (gain > 2.375) {
            gain = 2.375;
        }

        touchdown = (touchdown * 0.2);

        if (touchdown > 2.375) {
            touchdown = 2.375;
        }

        interception = (2.375 - (interception * 0.25));

        if (interception < 0) {
            interception = 0;
        }

        rating = (((completion + gain + touchdown + interception) / 6) * 100).toFixed(2);

        return rating;
    };

    sortNumber = function(a, b) {
        return b.Rating - a.Rating;
    }
});