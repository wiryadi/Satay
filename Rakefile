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
  task :all => [:clean, :compile, :test_all]
      
  desc "Build solutions using MSBuild"
  msbuildtask :compile do |msb|
    msb.properties = {:configuration => CONFIG}
    msb.targets [:Clean, :Build]
    msb.solution = FileList["#{SOLUTION_PATH}/*.sln"]
  end
  
  desc "Run all automated web acceptance test"
  task :test_all => [:clean, :compile]
  task :test_all do
	sh "#{GALLIO_EXE} " +  
		"#{TEST_ASSEMBLIES} " +
		"/plugin-directory:#{CONCORDION_PLUGIN_PATH} " +
		"/working-directory:#{OUTPUT_PATH} " +
		"/report-directory:#{REPORT_PATH} " +
		"/report-type:Html " +
		"/show-reports"
  end
  
  desc "run single test"
  task :test => [:clean, :compile]
  task :test, :fixture_type do |t, args|
	sh "#{GALLIO_EXE} " +  
		"#{TEST_ASSEMBLIES} " +
		"/plugin-directory:#{CONCORDION_PLUGIN_PATH} " +
		"/working-directory:#{OUTPUT_PATH} " +
		"/report-directory:#{REPORT_PATH} " +
		"/report-type:Html " +
		"/show-reports " +
		"/filter:Type:#{args.fixture_type}"
  end
  
  desc "Initialise the solution"
  task :init, :solution_name do |t, args| 
	puts "Initialising for #{args.solution_name}"
	sh "ren Satay.sln #{args.solution_name}.sln"
  end
end



