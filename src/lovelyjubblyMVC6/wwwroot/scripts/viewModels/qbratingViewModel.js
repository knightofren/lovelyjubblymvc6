define(['knockout', 'knockout.validation', 'common', 'components'], function (ko) {

    return function qbratingViewModel() {

        function qbrating(qbratingId, season, teamId, teamName, completion, gain, touchdown, interception, rating) {
            this.QbRatingId = qbratingId;
            this.Season = season;
            this.TeamId = teamId;
            this.TeamName = teamName;
            this.Completion = completion;
            this.Gain = gain;
            this.Touchdown = touchdown;
            this.Interception = interception;
            this.Rating = rating;
        }

        var self = this;

        // observable arrays are update binding elements upon array changes
        self.qbratings = ko.observableArray([]);
        
        self.Id = ko.observable(undefined);
        self.Season = ko.observable();
        self.TeamId = ko.observable();
        self.TeamName = ko.observable();
        self.Completion = ko.observable();
        self.Gain = ko.observable();
        self.Touchdown = ko.observable();
        self.Interception = ko.observable();
        self.Rating = ko.observable();

        var url = 'http://lovelyjubblymvc6.azurewebsites.net/api/qbratingsbyseason/' + Model.action;

        $.ajax({
            url: url,
            type: 'get',
            contentType: 'application/json',
            success: function (data) {
                self.qbratings.removeAll();
                $.each(data, function (i) {
                    self.Id(data[i].QbRatingId);
                    self.Season(data[i].Season);
                    self.TeamId(data[i].TeamId);
                    self.TeamName(data[i].TeamName);
                    self.Completion(data[i].Completion);
                    self.Gain(data[i].Gain);
                    self.Touchdown(data[i].Touchdown);
                    self.Interception(data[i].Interception);

                    self.qbratings.push(new qbrating(data[i].QbRatingId, data[i].Season,
                                            data[i].TeamId, data[i].Team.TeamName,
                                            data[i].Completion, data[i].Gain, data[i].Touchdown,
                                            data[i].Interception, self.Rating()));
                });
                //sorting
                self.qbratings.sort(sortNumber);

            },
            error: function (err) {
                console.log(err);
            }
        });

        self.Rating = ko.computed(function () {
            return calculateQBRating(self.Completion(), self.Gain(), self.Touchdown(), self.Interception());
        }, this);
    };
});