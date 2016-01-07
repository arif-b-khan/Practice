module.exports = function (config) {
    config.set({
        basePath : '../',
        
        files : [
            'Scripts/angular.js',
            'Scripts/angular-*.js',
            'app/js/**/*.js',
            'test/unit/**/*.js'            
        ],
        exclude: ['**/*scenario.js'],
        autoWatch : true,
        frameworks: ['jasmine'],
        browsers:['Firefox'],
        plugins : [
            'karma-junit-reporter',
            'karma-chrome-launcher',
            'karma-firefox-launcher',
            'karma-jasmine'
        ],
        
        junitReporter : {
            outputFile: 'test_out/unit.xml',
            suite: 'unit'
        }

    })
}
