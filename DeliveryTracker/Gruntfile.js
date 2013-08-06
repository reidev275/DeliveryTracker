module.exports = function (grunt) {

    // Project configuration.
    grunt.initConfig({
        pkg: grunt.file.readJSON('package.json'),
        jshint: {
            all: ['Scripts/*.js']
        },
        uglify: {
            my_target: {
                files: {
                    '<%= pkg.name %>.min.js': [
                        'Scripts/lib/jquery-1.9.1.min.js',
                        'Scripts/lib/jquery.cookie.js',
                        'Scripts/lib/knockout-2.2.1.js',
                        'Scripts/*.js']
                }
            }
        },
        csslint: {
            strict: {
                options: {
                    import: false
                },
                src: ['Content/Site.css']
            }
        },
        cssmin: {
            compress: {
                files: {
                    '<%= pkg.name %>.min.css': [
                        'Content/bootstrap3.min.css',
                        'Content/Site.css']
                }
            }
        }
    });

    //Load the plugins
    grunt.loadNpmTasks('grunt-contrib-jshint');
    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-contrib-csslint');
    grunt.loadNpmTasks('grunt-contrib-cssmin');

    // Default task(s).
    grunt.registerTask('js', ['jshint', 'uglify']);
    grunt.registerTask('css', ['csslint', 'cssmin']);
};