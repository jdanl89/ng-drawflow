export enum InputValidationType {
  // equals
  Eq,

  // not equals
  Ne,

  // greater than
  Gt,

  // greater than or equal to
  Ge,

  // less than
  Lt,

  // less than or equal to
  Le,

  // string matches wildcard pattern
  Like,

  // string doesn't match wildcard pattern
  NLike,

  // string matches regex pattern
  Match,

  // string doesn't match regex pattern
  NMatch,

  // collection contains a value
  Contains,

  // collection doesn't contain  a value
  NContains,

  // value is in a collection
  In,

  // value is not in a collection
  NotIn,
}
