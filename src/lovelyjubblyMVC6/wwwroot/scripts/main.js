require(['knockout', 'viewModels/teamViewModel', 'viewModels/fixtureViewModel', 'domReady!'], function (ko, teamViewModel, fixtureViewModel) {

    //require
    require({
        baseUrl: '/wwwroot',
        paths: {
            text: '/scripts/text'
        }
    });

    //validation
    ko.validation.rules.pattern.message = 'Invalid.';

    ko.validation.init({
        registerExtenders: true,
        messagesOnModified: true,
        insertMessages: true,
        parseInputAttributes: true,
        messageTemplate: null
    });

    //combine multiple view models into master view model as KO is designed for one view model per app
    //and one call to applyBindings
    var masterVM = { team: new teamViewModel(), fixture: new fixtureViewModel() };

    ko.applyBindingsWithValidation(masterVM);
});