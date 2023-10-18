/// <binding BeforeBuild='typescript, styles' />
'use strict';

const gulp = require('gulp');
const sass = require('gulp-sass')(require('sass'));
const ts = require("gulp-typescript");
const tsProject = ts.createProject("tsconfig.json");
const cleanCss = require('gulp-clean-css');
const minify = require('gulp-minify');
const watch  = require('gulp-watch');

function buildStyles() {
    return gulp.src('./Sass/StyleSheet.scss')
        .pipe(sass().on('error', sass.logError))
        .pipe(cleanCss())
        .pipe(gulp.dest('./wwwroot/css/'));
}

gulp.task("styles", buildStyles);

gulp.task("typescript", function () {
    return tsProject.src()
        .pipe(tsProject())
        .js.pipe(minify())
        .pipe(gulp.dest("./wwwroot/js"));
});

gulp.task("watchScss", function () {
    return watch('Sass/*.scss', buildStyles);
});