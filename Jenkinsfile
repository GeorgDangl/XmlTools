pipeline {
	agent {
		node {
			label 'master'
            customWorkspace 'workspace/XmlTools'
		}
	}
    environment {
        KeyVaultBaseUrl = credentials('AzureCiKeyVaultBaseUrl')
        KeyVaultClientId = credentials('AzureCiKeyVaultClientId')
        KeyVaultClientSecret = credentials('AzureCiKeyVaultClientSecret')
    }
    stages {
        stage ('Test') {
            steps {
                powershell './build.ps1 Test -configuration Debug'
            }
            post {
                always {
                    recordIssues(
                        tools: [
                            msBuild(), 
                            taskScanner(
                                excludePattern: '**/*node_modules/**/*, output/**/*', 
                                highTags: 'HACK, FIXME', 
                                ignoreCase: true, 
                                includePattern: '**/*.cs, **/*.g4, **/*.ts, **/*.js', 
                                normalTags: 'TODO')
                            ])
                    xunit(
                        testTimeMargin: '3000',
                        thresholdMode: 1,
                        thresholds: [
                            failed(failureNewThreshold: '0', failureThreshold: '0', unstableNewThreshold: '0', unstableThreshold: '0')
                        ],
                        tools: [
                            xUnitDotNet(deleteOutputFiles: true, failIfNotNew: true, pattern: '**/*testresults*.xml', stopProcessingIfError: true)
                        ])
                }
            }
        }
        stage ('Deploy') {
            steps {
                powershell './build.ps1 UploadDocumentation+PublishGitHubRelease'
            }
        }
    }
    post {
        always {
            step([$class: 'Mailer',
                notifyEveryUnstableBuild: true,
                recipients: "georg@dangl.me",
                sendToIndividuals: true])
            cleanWs()
        }
    }
}
