OPTIONS="--options=./.astyle"
astyle --version

RETURN=0
ASTYLE=$(which astyle)
for FILE in `\find . -name '*.cs'`; do
  TEMP=$(mktemp)
  $ASTYLE $OPTIONS < $FILE > $TEMP
  if ! cmp -s "$FILE" $TEMP; then
    echo "error: $FILE does not respect with coding style"
    RETURN=1
  fi
  rm $TEMP
done
exit $RETURN
