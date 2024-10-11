/*
 * gulpfile tasks
 * 
 * gulp build - builds assets for production
 * gulp watch - watches for css and js file changes
 * 
 */

const gulp = require('gulp');
const clean = require('gulp-clean');
const concat = require('gulp-concat');
const postcss = require('gulp-postcss');
const rename = require('gulp-rename');
const uglify = require('gulp-uglify');

//style sources
const stylesSource = './src/css/site.css';


// output dirs
const outputDir = './wwwroot';
const stylesOutputDir = outputDir + '/css';

// clean sources
const cleanSource = [
    outputDir + '/css/*',
];

// watch sources
const watchStyles = [
    './src/**/*',
    './Views/**/*.cshtml'
];

function cleanUp() {
    return gulp.src(cleanSource, { read: false, allowEmpty: true })
        .pipe(clean());
}

function buildStyles() {
    return gulp.src(stylesSource)
        .pipe(postcss())
        .pipe(rename({ suffix: '.min' }))
        .pipe(gulp.dest(stylesOutputDir));
}

function watchAll() {
    gulp.watch(watchStyles, buildStyles);
}

exports.watch = gulp.series(cleanUp, buildStyles, watchAll);
exports.build = gulp.series(cleanUp, buildStyles);