
var camelCaseTokenizer = function (builder) {

  var pipelineFunction = function (token) {
    var previous = '';
    // split camelCaseString to on each word and combined words
    // e.g. camelCaseTokenizer -> ['camel', 'case', 'camelcase', 'tokenizer', 'camelcasetokenizer']
    var tokenStrings = token.toString().trim().split(/[\s\-]+|(?=[A-Z])/).reduce(function(acc, cur) {
      var current = cur.toLowerCase();
      if (acc.length === 0) {
        previous = current;
        return acc.concat(current);
      }
      previous = previous.concat(current);
      return acc.concat([current, previous]);
    }, []);

    // return token for each string
    // will copy any metadata on input token
    return tokenStrings.map(function(tokenString) {
      return token.clone(function(str) {
        return tokenString;
      })
    });
  }

  lunr.Pipeline.registerFunction(pipelineFunction, 'camelCaseTokenizer')

  builder.pipeline.before(lunr.stemmer, pipelineFunction)
}
var searchModule = function() {
    var documents = [];
    var idMap = [];
    function a(a,b) { 
        documents.push(a);
        idMap.push(b); 
    }

    a(
        {
            id:0,
            title:"SafeMode",
            content:"SafeMode",
            description:'',
            tags:''
        },
        {
            url:'/cake.asciidoctorj/api/Cake.AsciiDoctorJ/SafeMode',
            title:"SafeMode",
            description:""
        }
    );
    a(
        {
            id:1,
            title:"BuiltinBackend",
            content:"BuiltinBackend",
            description:'',
            tags:''
        },
        {
            url:'/cake.asciidoctorj/api/Cake.AsciiDoctorJ/BuiltinBackend',
            title:"BuiltinBackend",
            description:""
        }
    );
    a(
        {
            id:2,
            title:"AsciiDoctorJAliases",
            content:"AsciiDoctorJAliases",
            description:'',
            tags:''
        },
        {
            url:'/cake.asciidoctorj/api/Cake.AsciiDoctorJ/AsciiDoctorJAliases',
            title:"AsciiDoctorJAliases",
            description:""
        }
    );
    a(
        {
            id:3,
            title:"AsciiDoctorJRunnerSettingsExtensions",
            content:"AsciiDoctorJRunnerSettingsExtensions",
            description:'',
            tags:''
        },
        {
            url:'/cake.asciidoctorj/api/Cake.AsciiDoctorJ/AsciiDoctorJRunnerSettingsExtensions',
            title:"AsciiDoctorJRunnerSettingsExtensions",
            description:""
        }
    );
    a(
        {
            id:4,
            title:"DocType",
            content:"DocType",
            description:'',
            tags:''
        },
        {
            url:'/cake.asciidoctorj/api/Cake.AsciiDoctorJ/DocType',
            title:"DocType",
            description:""
        }
    );
    a(
        {
            id:5,
            title:"ERuby",
            content:"ERuby",
            description:'',
            tags:''
        },
        {
            url:'/cake.asciidoctorj/api/Cake.AsciiDoctorJ/ERuby',
            title:"ERuby",
            description:""
        }
    );
    a(
        {
            id:6,
            title:"AsciiDoctorJRunnerSettings",
            content:"AsciiDoctorJRunnerSettings",
            description:'',
            tags:''
        },
        {
            url:'/cake.asciidoctorj/api/Cake.AsciiDoctorJ/AsciiDoctorJRunnerSettings',
            title:"AsciiDoctorJRunnerSettings",
            description:""
        }
    );
    var idx = lunr(function() {
        this.field('title');
        this.field('content');
        this.field('description');
        this.field('tags');
        this.ref('id');
        this.use(camelCaseTokenizer);

        this.pipeline.remove(lunr.stopWordFilter);
        this.pipeline.remove(lunr.stemmer);
        documents.forEach(function (doc) { this.add(doc) }, this)
    });

    return {
        search: function(q) {
            return idx.search(q).map(function(i) {
                return idMap[i.ref];
            });
        }
    };
}();
