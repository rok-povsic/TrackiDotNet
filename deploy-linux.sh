#!/bin/bash

rsync -av --progress TrackiCore/bin/Release/netcoreapp3.1/* ~/Dropbox/Tracki/TrackiCore-new --exclude data
