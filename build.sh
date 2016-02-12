#!/bin/bash
BUILD_FOLDER="./artifacts"

PROJECT_FOLDER="./src/Truewheelers"

function vdo {
    echo "+ $@"
    $@
}

if [ $? -eq 0 ]; then
	vdo dnu restore

	vdo dnu build  $PROJECT_FOLDER --out $BUILD_FOLDER

	exit $?
fi

>&2 echo "Failed to build"
	exit 1
