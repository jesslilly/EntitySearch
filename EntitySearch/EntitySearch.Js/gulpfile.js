var gulp = require('gulp');

var concat = require('gulp-concat');
var uglify = require('gulp-uglify');
var rjs = require('gulp-requirejs');

var paths = {
	gd : ['js/*.js'],
	js : ['js/**/*.js'],
	gulpfile : ['gulpfile.js'],
	images : 'img/**/*'
};

gulp.task('requirejsBuild', function () {
	rjs({
		name : "entity-search",
		baseUrl : 'js',
		out : 'entity-search.min.js',
		shim : {
		// standard require.js shim options
		},
	// ... more require.js options
	}).pipe(uglify()).pipe(gulp.dest('./build/js/')); // pipe to output DIR
});

// Rerun the task when a file changes
gulp.task('watch', function () {
	gulp.watch(paths.js, ['requirejsBuild']);
	gulp.watch(paths.gulpfile, ['requirejsBuild']);
});

// The default task (called when you run `gulp` from cli)
gulp.task('default', ['requirejsBuild', 'watch']);