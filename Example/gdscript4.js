/**
 *  Create by Alex Thubeauville   
 * */
const KEYWORDS = {
    keyword: "if elif else for while for match when break continue pass return class class_name extends is in as self super signal " +
        "func static const enum var breakpoint await yield assert void const and not or",
    built_in: "new enum @",
    literal: "null false true PI TAU INF NAN",
    type: "bool int float String StringName Vector2 Vector2i Vector3 Vector3i  Rect2 Transform2D Plane Quaternion AABB Basis Transform3D " +
        "Color RID Object Array PackedByteArray PackedInt32Array PackedInt64Array PackedFloat32Array PackedFloat64Array PackedStringArray " +
        "PackedVectorArray PackedVector3Array PackedVecto4Array PackedColorArray Dictionary Signal Callable",
};

const METHOD_CALL = {
    className: 'title function',
    begin: /[a-zA-Z_][a-zA-Z0-9_]*(?=\()/,
    excludeEnd: true,
    relevance: 0,
    keywords: KEYWORDS
};

const OPERATOR = {
    className: "operator",
    begin: /(=|\+|\-|\~|\*|\/|\>|\<|\%|\!)/
};

const PARENTHESIS = {
    className: "title function",
    begin: /(\(|\)|\]|\[|\{|\})/,
    relevance: 0
};


const TYPE = {
    begin: /:\s?/,
    contains: [
        {
            className: "type",
            begin: /s*[a-zA-Z0-9]+/,
            relevance: 0
        }
    ]
};

const ENUM = {
    className: 'enum',
    beginKeywords: 'enum',
    end: /\}/,
    excludeBegin: true,
    contains: [
        {
            className: 'type',
            begin: /[a-zA-Z_][a-zA-Z0-9_]*/,
            end: /(?=\{)/,
            excludeEnd: true,
            relevance: 0
        },
        {
            begin: /\{/,
            end: /\}/,
            endsParent: true,
            contains: [
                {
                    className: 'keyword',
                    begin: /[A-Z][A-Z0-9_]*/,
                    relevance: 0
                }
            ]
        }
    ]
};

const ENUM_ACCESS = {
    begin: /\./,
    excludeBegin: true,
    contains: [
        {
            className: "keyword",
            begin: /\b[A-Z][A-Z_]+/,
            relevance: 0
        }
    ]
};

const LITERAL = {
    className: "literal",
    begin: /\b-?[0-9]+/
};

const CLASS = {
    begin: /(extends|class|class_name)\s/,
    excludeBegin: true,
    contains: [
        {
            className: "title function",
            begin: /[A-Z][a-zA-Z0-9_]*/,
        }
    ]
};

const CLASS_WILD = {
    className: "type",
    begin: /[A-Z][a-zA-Z0-9_]+/,
};

const CONSTANT = {
    className: 'constant',
    begin: /\b[A-Z][A-Z0-9_]*\b/,
    relevance: 0
};

function GDScript(hljs) {
    return {
        keywords: KEYWORDS,
        contains: [
            hljs.HASH_COMMENT_MODE,
            hljs.QUOTE_STRING_MODE,
            METHOD_CALL,
            PARENTHESIS,
            OPERATOR,
            LITERAL,
            ENUM,
            ENUM_ACCESS,
            TYPE,
            CLASS,
            CONSTANT,
            CLASS_WILD,
        ]
    };
}
window.GDScript = GDScript;