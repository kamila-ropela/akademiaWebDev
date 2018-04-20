import PropTypes from "prop-types";

const LinkInterface = PropTypes.shape({
  id: PropTypes.number.required,
  FullUrl: PropTypes.string.required,
  ShortUrl: PropTypes.string.required,
});

export default LinkInterface;
