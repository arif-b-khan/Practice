module.exports = function (config) {
    config.set({
        basePath: '../',
        
        hostname: "localhost",
        port: "8000",
        runnerPort: 0,
        //files: [
        //    'app/lib/angular/angular.js',
        //    'app/lib/angular/angular-*.js',
        //    'app/lib/angular/angular-mocks.js',
        //    'app/js/**/*.js',
        //    'test/unit/**/*.js'
        //],
        files: [
            'Scripts/angular.js',
            'Scripts/angular-*.js',
            'app/js/**/*.js',
            'test/unit/**/*.js'            
        ],
        exclude: ['**/*scenario.js',
            'test/unit/directivesSpec.js'],
        autoWatch: true,
        frameworks: ['jasmine'],
        browsers: ['PhantomJS_custom'],
        customLaunchers: {
            'PhantomJS_custom': {
                base: 'PhantomJS',
                options: {
                    windowName: 'my-window',
                    settings: {
                        webSecurityEnabled: false
                    },
                },
                flags: ['--load-images=true'],
                debug: true
            }
        },
        phantomjsLauncher: {
            // Have phantomjs exit if a ResourceError is encountered (useful if karma exits without killing phantom) 
            exitOnResourceError: true
        },
        plugins: ['karma-jasmine', 'karma-phantomjs-launcher', 'karma-ng-scenario'],
        junitReporter: {
            outputFile: 'test_out/unit.xml',
            suite: 'unit'
        }
    })
}
