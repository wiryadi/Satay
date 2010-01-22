require 'rake/clean'
require 'rake/tasklib'
require 'albacore'

SOLUTION_PATH = "." 
OUTPUT_PATH = "build"

CONFIG = ENV['CONFIG'] || "Debug"
ENVIRONMENT = ENV['ENVIRONMENT'] || "dev"
 
CLEAN.include(OUTPUT_PATH)

task :default => "satay:all"
 
namespace :satay do
  
  task :all => [:clean, :compile, :config, :test]
      
  desc "Build solutions using MSBuild"
  msbuildtask :compile do |msb|
    msb.properties = {:configuration => CONFIG}
    msb.targets [:Clean, :Build]
    msb.solution = FileList["#{SOLUTION_PATH}/*.sln"]
  end
  
  desc "Generate app and web config files for correct environment"
  task :config do
    ["app", "web"].each do |config_type|
      FileList["src/**/#{config_type}.config"].each do |file|
        e = ExpandTemplates.new
        e.data_file = "config/environments/#{ENVIRONMENT}.yml"
        e.expand_files = {"config/#{config_type}.template.config" => file }
        e.expand
      end
    end
  end

  desc "Run automated web acceptance test"
  task :test do
  
  end

end

