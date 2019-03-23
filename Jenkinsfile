pipeline {
    agent any
    stages {
        stage('Prepare DocFx') {
            steps {
                dir('_site') {
                    deleteDir()
                }
                dir('docfx') {
                    script {
                        if(!fileExists('docfx.exe')){
                            sh 'wget "https://github.com/dotnet/docfx/releases/download/v2.40.12/docfx.zip"'
                            sh 'unzip docfx.zip'
                        }
                    }
                }
            }
        }

        stage('Pull GitHub projects') {
            steps {
                dir('bepis_docs') {
                    deleteDir()
                    git url: 'https://github.com/BepInEx/bepinex_docs.git'
                    dir('src') {
                        git url: 'https://github.com/BepInEx/BepInEx.git'
                        sh 'git submodule update --init --recursive'
                    }
                }
            }
        }

        stage('Generate docs') {
            steps {
                dir('bepis_docs') {
                    sh 'mono ../docfx/docfx.exe'
                    sh 'mv _site ..'
                }
            }
        }

        stage('Push updated docs') {
            steps {
                dir('bepis_docs') {
                    sh 'git checkout gh-pages'
                    sh 'rm -r *'
                    sh 'mv ../_site/* .'
                    sh 'git config user.name bepin-jenkins'
                    sh 'git config user.email bepin-jenkins@protonmail.com'
                    sh 'git add .'
                    sh 'git commit -m "Update docs"'
                    withCredentials([usernamePassword(credentialsId: 'ceb99705-5860-45ff-b100-c07e5f90902f', passwordVariable: 'GIT_PASSWORD', usernameVariable: 'GIT_USERNAME')]) {
                        sh('git push https://${GIT_USERNAME}:${GIT_PASSWORD}@github.com/BepInEx/bepinex_docs.git gh-pages')
                    }
                }
            }
        }
    }
}