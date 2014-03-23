
require 'albacore'
require 'find'


#  Find any tests that end with '.tests.dll' for the given build type
#  assuming that is built into bin/<build_type>
def find_tests(root, build_type)
    paths = []
    re = Regexp.new(".*/bin/#{build_type}.*Tests\.dll$", Regexp::IGNORECASE)
    Find.find(root) do |path|
        paths << path if path =~ re
    end
    return paths
end

#  Define the root relative to this file.
ROOT=File.expand_path('.', File.dirname(__FILE__))

PACKAGES_DIR=File.join(ROOT, 'packages')

#  What we're building
SOLUTION=File.join(ROOT, 'Refractored.MvxPlugins.sln' )

#  Nuget binary
NUGET_EXE = File.join(ROOT, '.nuget/nuget.exe')

#  Multi-cpu compile, no logo, low verbosity
COMPILER_SWITCHES = {
    'M' => true,
    'verbosity' => 'normal',
    'nologo' => true
}


#  Relative to this file
desc 'Restore nuget packages'
task :restore_packages do
    FileList["**/packages.config"].each do |filepath|
        sh "#{NUGET_EXE} install #{filepath} -OutputDirectory #{PACKAGES_DIR}"
    end
end

desc "Update nuget"
exec :update_nuget do |cmd|
    cmd.command = NUGET_EXE
    cmd.parameters = "update -Self"
end


desc 'Set up everything if checked out for the first time'
task :setup => [:restore_packages]


desc 'Clean entire build'
task :clean => ["release:clean", "debug:clean"]


desc 'Build everything'
task :build => ["debug:build", "release:build"]


desc 'Clean, rebuild'
task :preflight => [:setup, :clean, :build]


########################################################################################################################
#  Debug tasks
########################################################################################################################


namespace 'debug' do
    desc 'Build'
    msbuild :build do |msb|
        msb.properties = { :configuration => :Debug }
        msb.targets = [ :Build ]
        msb.other_switches = COMPILER_SWITCHES
        msb.solution = SOLUTION
    end

    desc 'Clean'
    msbuild :clean do |msb|
        msb.properties = { :configuration => :Debug }
        msb.targets = [ :Clean ]
        msb.other_switches = COMPILER_SWITCHES
        msb.solution = SOLUTION
    end

end


########################################################################################################################
#  Release tasks
########################################################################################################################


namespace 'release' do
    desc 'Build'
    msbuild :build do |msb|
        msb.properties = { :configuration => :Release, :platform => 'Any CPU' }
        msb.targets = [ :Build ]
        msb.other_switches = COMPILER_SWITCHES
        msb.solution = SOLUTION
    end

    desc 'Clean'
    msbuild :clean do |msb|
        msb.properties = { :configuration => :Release, :platform => 'Any CPU' }
        msb.targets = [ :Clean ]
        msb.other_switches = COMPILER_SWITCHES
        msb.solution = SOLUTION
    end
end




