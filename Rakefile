require 'rake/clean'
require 'rake/tasklib'
require 'albacore'

SOLUTION_PATH = "." 
OUTPUT_PATH = "build"
LIB_PATH = "lib"
TOOL_PATH = "tools"
GALLIO_EXE = "#{TOOL_PATH}\\Gallio\\bin\\Gallio.Echo.exe"
CONCORDION_PLUGIN_PATH = "lib\\concordion"
REPORT_PATH = "Reports"
OBJ_FILES = "src/*/obj"

CONFIG = ENV['CONFIG'] || "Debug"
ENVIRONMENT = ENV['ENVIRONMENT'] || "dev"

TEST_ASSEMBLIES = "#{OUTPUT_PATH}\\Specifications.dll"

#define temporary obj files to be removed
CLEAN.include(OBJ_FILES)
 
#define old outputs to be removed
CLOBBER.include(OUTPUT_PATH, REPORT_PATH)

task :default => "satay:all"
 
namespace :satay do
  task :all => [:clean, :compile, :config, :test]
      
  desc "Build solutions using MSBuild"
  msbuildtask :compile do |msb|
    msb.properties = {:configuration => CONFIG}
    msb.targets [:Clean, :Build]
    msb.solution = FileList["#{SOLUTION_PATH}/*.sln"]
  end
  
  desc "Run automated web acceptance test"
  task :test do
	sh "#{GALLIO_EXE} " +  
		"#{TEST_ASSEMBLIES} " +
		"/plugin-directory:#{CONCORDION_PLUGIN_PATH} " +
		"/working-directory:#{OUTPUT_PATH} " +
		"/report-directory:#{REPORT_PATH} " +
		"/report-type:Html " +
		"/show-reports"
  end
end

